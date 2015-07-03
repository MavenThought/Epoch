// include Fake lib
#r @"../packages/FAKE/tools/FakeLib.dll"


open System.IO
open Fake

RestorePackages()

#load "./config.fsx"
#load "./userInput.fsx"
#load "./version.fsx"
#load "./package.fsx"
#load "./Test.fsx"

open Config

// Targets
Target "Clean" (fun _ ->
    CleanDirs [buildDir]
)

let addBuildTarget name env sln =
    let rebuild config = {(setParams config) with Targets = ["Rebuild"]}
    Target (targetWithEnv name env) (fun _ ->
        setBuildMode env
        build rebuild sln
    )

targets |> Seq.iter (fun t -> addBuildTarget "Epoch" t epochSln)


// start build
RunTargetOrDefault "Epoch:Debug"