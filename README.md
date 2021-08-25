# FSharp.ShellExec

## Usage

```fsharp
open FSharp.ShellExec

Shell.exec "echo" ["hello"]
|> printfn "%A"
```

### Output

```text
Ok "hello
"
```

## Development

### Run tests

```bash
dotnet test
```
