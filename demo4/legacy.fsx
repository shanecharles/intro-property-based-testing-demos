#I "../packages/FsCheck/lib/net452/"
#r "FsCheck.dll"

#I "moneybusiness/bin/Debug/netcoreapp1.1/"
#r "MoneyBusiness.dll"

open FsCheck
open MoneyBusiness

let award = MoneyMaking.Award

let ``Awarding money should not contain a zero`` (xs : int list) =
    xs |> award 
       |> Seq.forall (fun x -> x <> 0)

let config = { 
    Config.Quick with
        EndSize = 5000
    }

Check.One("Contain No Zeroes", config, ``Awarding money should not contain a zero``)



let ``Awarding money output should have the same length as the input length`` (xs : int list) =
    xs |> List.length = (xs |> award |> Seq.length)



Check.One("Input length equals output length", config, ``Awarding money output should have the same length as the input length``)
