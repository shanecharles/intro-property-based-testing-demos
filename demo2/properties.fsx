#I "../packages/FsCheck/lib/net452/"
#r "FsCheck.dll"

#I "thereandback/bin/debug/"
#r "ThereAndBack.dll"

open FsCheck
open System

let encryption = ThereAndBack.Encryption ()

let ``Check There And Back of DateTime Encryption`` (input : DateTime) =
  input = (input.ToString() 
            |> encryption.EncryptStringToBytes_Aes 
            |> encryption.DecryptStringFromBytes_Aes 
            |> DateTime.Parse)


Check.Quick ``Check There And Back of DateTime Encryption``



let ``Check There And Back Strings`` (NonEmptyString input) =
  input = (input |> encryption.EncryptStringToBytes_Aes 
            |> encryption.DecryptStringFromBytes_Aes)


Check.Quick ``Check There And Back Strings``
