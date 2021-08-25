module Tests

open Xunit
open FSharp.ShellExec

[<Fact>]
let ``Exec command`` () =
    let res = Shell.exec "echo" ["hello"]
    Assert.Equal(Ok "hello\n", res)
