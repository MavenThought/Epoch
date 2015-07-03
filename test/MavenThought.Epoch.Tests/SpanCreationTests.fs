module MavenThought.Epoch.Tests.``Span Creation tests``

open System
open FsCheck
open FsCheck.NUnit
open MavenThought.Epoch 

let mkSpan hours = new TimeSpan(hours, 0, 0)

[<Property>]
let ``When using minutes returns the minutes span`` some =
    some > 0 ==> (some .Minutes().Span = new TimeSpan(0, some, 0))

[<Property>]
let ``When using hours returns the hours span`` some =
    some > 0 ==> (some .Hours().Span = mkSpan some)

[<Property>]
let ``When using days returns the days span`` some =
    some > 0 ==> (some .Days().Span = mkSpan (some * 24))

[<Property>]
let ``When using weeks returns the weeks span`` some =
    some > 0 ==> (some .Weeks().Span = mkSpan (some * 24 * 7))


    