# FSharp.ShellExec

## Usage

### Synchronous version

```fsharp
open FSharp.ShellExec

Shell.exec "echo" ["hello"]
|> printfn "%A"
```

Output:

```text
Ok "hello
"
```

### Asynchronous version

```fsharp
open FSharp.ShellExec

Shell.execAsync "echo" ["hello"]
|> Async.RunSynchronously
|> printfn "%A"
```

Output:

```text
Ok "hello
"
```

### Reactive version

```fsharp
open FSharp.ShellExec

let output = Shell.execRx "echo" ["hello"]  // : IObservable<string>
output.Subscribe(printfn "%s")
```

Output:

```text
hello

```

## Development

### Run tests

```bash
dotnet test
```
