// include Fake lib
#r @"../packages/FAKE/tools/FakeLib.dll"


open Fake

// Properties
[<AutoOpen>]
module Config =
  let buildDir     = "./build/"
  let testDir      = "./test/"
  let srcDir       = "./source/"
  let epochSln     = "MavenThought.Epoch.sln"
  let prjName      = "MavenThought.Epoch"
  let prjFolder    = srcDir @@ prjName
  let prj          = prjFolder @@ prjName + ".csproj"
  let buildMode () = getBuildParamOrDefault "buildMode" "Release"
  let version      = "0.0.0.0"
  let targetWithEnv target env = sprintf "%s:%s" target env

  let setBuildMode = setEnvironVar "buildMode"

  let targets      = ["Release"; "Debug"]
  let debugMode   () = setBuildMode "Debug"
  let releaseMode () = setBuildMode "Release"

  let setParams defaults =
    { defaults with
        Targets = ["Build"]
        Properties =
            [
                "Optimize", "True"
                "Platform", "Any CPU"
                "Configuration", buildMode()
            ]
        }











