// include Fake lib
#r @"../packages/FAKE/tools/FakeLib.dll"


open Fake

[<AutoOpen>]
module UserInput = 
    let changeColorTo color = System.Console.ForegroundColor <- color

    let resetColor = System.Console.ResetColor

    let confirmAction question goAheadFn =
        printf "%s (Y/N)" question
        let option = System.Console.ReadLine()
        match option with
            | "Y" -> goAheadFn()
            | _ -> ignore()

    let chooseAnOption (question: string, options: string seq) =
        let options = options |> List.ofSeq
        changeColorTo System.ConsoleColor.Blue
        printf "%s\n" question
        changeColorTo System.ConsoleColor.Yellow
        options |> Seq.iteri (fun i opt -> printf "%d: %s\n" (i+1) opt)
        let option = System.Console.ReadLine()
        let isValidOption chosen = chosen >= 1 && chosen <= options.Length
        match System.Int32.TryParse option with
            | true, i when isValidOption i -> Some(i-1, List.nth options (i-1))
            | _ ->  None   

