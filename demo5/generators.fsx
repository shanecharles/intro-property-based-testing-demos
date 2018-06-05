#I "../packages/FsCheck/lib/net452/"
#r "FsCheck.dll"

#I "complextype/bin/Debug/netcoreapp1.1/"
#r "ComplexType.dll"

open FsCheck
open ComplexType

let genValidName = Gen.elements [ "Sarah"; "Susan"; "Bob"; "Jen"; "Doug"; "Cam"; "Jeff"; "Bonnie" ]

let genValidAge = Gen.choose (14, 110)

let genLowRisk = Gen.constant RiskFactor.Low



let genPerson name age risk =
    gen {
        let! n = name
        let! a = age
        let! r = risk
        return Person(n, a, r)
    }

genPerson genValidName genValidAge genLowRisk |> Gen.sample 0 10
