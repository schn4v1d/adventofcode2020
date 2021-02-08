// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open FParsec.CharParsers
open FParsec.Primitives

let range =
    (pint32 .>> pstring "-")
    .>>. (pint32 .>> pstring " ")

let rule = anyChar .>> pstring ": "

let password = manyChars anyChar

let pline = tuple3 range rule password

let lines = System.IO.File.ReadAllLines "input"

let unwrapResult res =
    match res with
    | Success (result, _, _) -> result
    | Failure (_) -> ((0, 0), ' ', "")

let count x = Seq.filter ((=) x) >> Seq.length

let validPasswordPartOne ((lower, upper), char, password) =
    let c = count char password
    lower <= c && c <= upper

let validPasswordPartTwo ((lower, upper), char, password: string) =
    let first = password.[lower - 1]
    let second = password.[upper - 1]
    (first = char) <> (second = char)

[<EntryPoint>]
let main argv =
    printfn
        "Part One: %A"
        (count
            true
            (Array.map
                ((run pline)
                 >> unwrapResult
                 >> validPasswordPartOne)
                lines))
    printfn
        "Part Two: %A"
        (count
            true
            (Array.map
                ((run pline)
                 >> unwrapResult
                 >> validPasswordPartTwo)
                lines))
    0 // return an integer exit code
