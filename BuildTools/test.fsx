#r @"../packages/FAKE/tools/FakeLib.dll"

#load "./config.fsx"

open System.IO
open Fake
open Config
open System.Configuration

let allTests = Map["Epoch", "MavenThought.Epoch.Tests"]

let testFiles testPrj = sprintf "test/%s/bin/%s/*Tests.dll" testPrj (buildMode())

let runTests files =
    files
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true
             OutputFile = testDir + "/TestResults.xml" })

let addTestTarget targetName testPrj =
    let csProj = sprintf "./test/%s/%s.csproj" testPrj testPrj
    let fsProj = sprintf "./test/%s/%s.fsproj" testPrj testPrj
    let prjFile = (if fileExists csProj then csProj else fsProj)

    Target ("Test:" + targetName) (fun _ ->
        (debugMode ())
        let testParams defaults = 
            {(setParams defaults) with
                Properties = 
                [
                    "Configuration", buildMode()
                    "Platform", "AnyCPU"
                ]
            }

        build testParams prjFile
        !! (testFiles testPrj) |> runTests
    )


Target "Test" (fun _ -> 
    let addPrefix = (+) "Test:"
    allTests 
    |> Map.iter (fun name _ -> name |> addPrefix |> run)
)

allTests |> Map.iter addTestTarget

