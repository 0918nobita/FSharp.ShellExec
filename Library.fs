module FSharp.ShellExec.Shell

open System
open System.Diagnostics
open System.Reactive.Linq
open FSharp.Control.Reactive

let exec (cmd: string) (args: string list) : Result<string, string> =
    use p = new Process()
    p.StartInfo.FileName <- cmd
    p.StartInfo.Arguments <- String.concat " " args
    p.StartInfo.RedirectStandardOutput <- true

    try
        p.Start() |> ignore
        p.StandardOutput.ReadToEnd() |> Ok
    with
    | e -> Error e.Message

let execAsync (cmd: string) (args: string list) : Async<Result<string, string>> = async { return exec cmd args }

let execRx (cmd: string) (args: string list) : IObservable<string> =
    let p = new Process()
    p.StartInfo.FileName <- cmd
    p.StartInfo.Arguments <- String.concat " " args
    p.StartInfo.RedirectStandardOutput <- true
    let subject = Subject.replay
    p.OutputDataReceived.Add(fun args -> subject.OnNext(args.Data))
    p.Exited.Add(fun _ -> subject.OnCompleted())
    p.EnableRaisingEvents <- true

    try
        p.Start() |> ignore
        p.BeginOutputReadLine()
    with
    | e -> subject.OnError(e)

    subject.AsObservable()
