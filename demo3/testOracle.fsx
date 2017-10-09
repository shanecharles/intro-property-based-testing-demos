#I "../packages/FsCheck/lib/net452"
#r "FsCheck.dll"

open FsCheck
open System.Collections.Generic

let dblLinear n =
    let rec loop (x, xs) =
        seq {
            let x' :: next = (2UL * x + 1UL) :: (3UL * x + 1UL) :: xs
                             |> List.distinct
                             |> List.sort
            yield x'
            yield! loop (x', next)
        }
    loop (0UL, []) |> Seq.item n




#time
dblLinear 5000
#time

let dblLinear' n =
    let xs = new SortedSet<uint64>()
    let insert = Seq.iter (xs.Add >> ignore)
    let removeMin () = xs.Min |> (fun m -> xs.Remove(m) |> ignore; m) 
    Seq.unfold (fun x ->
        insert [ 2UL * x + 1UL; 3UL * x + 1UL ]
        let x' = removeMin ()
        Some (x', x')) (0UL)
    |> Seq.item n


#time
dblLinear' 5000
#time

let ``Performance improved should have same result as original`` (PositiveInt n) =
    dblLinear n = dblLinear' n


Check.Verbose ``Performance improved should have same result as original``



let config = {
    Config.Verbose with 
        EndSize = 5000
        MaxTest = 5
    }


Check.One("Test Oracle", config, ``Performance improved should have same result as original``)
