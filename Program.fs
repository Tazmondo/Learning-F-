open System

let getOperationInput () =
    printf "Enter your desired operation.\n"
    Console.ReadLine()

let isValidOperation (operation: string) =
    match operation.ToLower() with
    | "add" |"subtract" |"multiply" |"divide" -> true
    |_ -> false


let rec getValidOperation operation =
    match isValidOperation operation with
    | true -> operation
    | false -> getValidOperation (getOperationInput())


let selectedOperation = getValidOperation (getOperationInput ())
printfn "Valid operation: %s" selectedOperation

let getValueInputs () =
    printf "Enter your values:\n"
    let valueInput = Console.ReadLine()
    match valueInput with
        | "" | _ when valueInput.Contains "  " -> ["0.0"]
        | _ -> valueInput.Split(" ") |> Seq.toList
    
let result =
    match selectedOperation with
        | "add" ->
            let valueList = getValueInputs()
            List.sumBy float valueList

        | "subtract" ->
            let valueList = getValueInputs()
            let valueListFloat = List.map float valueList
            valueListFloat.Head - List.sum valueListFloat.Tail

        | "multiply" ->
            let valueList = List.map float (getValueInputs())
            
            let rec getProducts list total =
                match list with
                | [] -> total
                |_ -> getProducts list.Tail list.Head * total

            getProducts valueList 1.0

        | "divide" ->
            let valueList = List.map float (getValueInputs())
            match valueList.Length with
                | 0 -> 0.0
                | 1 -> valueList.Head
                | _ ->valueList.Head / valueList.Item(1)

        | _ -> 0.0

printfn "The result is: %A" result
Console.ReadLine()