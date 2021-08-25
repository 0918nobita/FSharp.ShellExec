module Tests

open FSharp.Control.Reactive
open FSharp.ShellExec
open Xunit

[<Fact>]
let ``Exec command (sync)`` () =
    let res = Shell.exec "echo" [ "hello" ]
    Assert.Equal(Ok "hello\n", res)

[<Fact>]
let ``Exec command (async)`` () =
    let res =
        Shell.execAsync "echo" [ "hello" ]
        |> Async.RunSynchronously

    Assert.Equal(Ok "hello\n", res)

[<Fact>]
let ``Exec command (rx)`` () =
    let output =
        Shell.execRx "echo" [ "hello" ] |> Observable.wait

    Assert.Equal("hello", output)
