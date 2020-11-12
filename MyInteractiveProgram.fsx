open System

let isValidOperation (operation: string) =
    match  with
    | "add" |"subtract" |"multiply" |"divide" -> true
    |_ -> false


let rec getValidOperation operation =
    printf "Enter your desired operation.\n"
    match isValidOperation operation with
    | true -> operation
    | false -> getValidOperation (Console.ReadLine())


let selectedOperation = getValidOperation (Console.ReadLine())
printf "Valid operation: %s" selectedOperation