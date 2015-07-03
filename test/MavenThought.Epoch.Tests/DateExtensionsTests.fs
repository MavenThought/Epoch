module MavenThought.Epoch.Tests.``Date extensions tests``

open System
open FsCheck
open FsCheck.NUnit
open MavenThought.Epoch

let sub some fn = -some |> float |> fn
let add some fn = some  |> float |> fn
let toDate (d:DateTime) = d.Date

module ``Some time Ago extensions`` =
    
    [<Property>]
    let ``Returns the seconds ago`` (some:int) =
        some > 0 ==> (some .Seconds().Ago = (sub some DateTime.Now.AddSeconds))

    [<Property>]
    let ``Returns the minutes ago`` (some:int) =
        some > 0 ==> (some .Minutes().Ago = (sub some DateTime.Now.AddMinutes))

    [<Property>]
    let ``Returns the days ago`` (some:int) =
        some > 0 ==> (some .Days().Ago = (sub some DateTime.Now.AddDays))

    [<Property>]
    let ``Returns the years ago`` (some:int) =
        some > 0 ==> (some .Years().Ago.Date = (-some |> DateTime.Now.AddYears |> toDate))

    [<Property>]
    let ``Returns the months ago`` some =
        some > 0 ==> (some .Months().Ago.Date = (-some |> DateTime.Today.AddMonths |> toDate))

    [<Property>]
    let ``Returns the weeks ago`` some =
        some > 0 ==> (some .Weeks().Ago = (sub (some*7) DateTime.Now.AddDays))

module ``Some time FromNow extensions`` =

    [<Property>]
    let ``Returns the seconds from now`` some =
        some > 0 ==> (some .Seconds().FromNow = (add some DateTime.Now.AddSeconds))

    [<Property>]
    let ``Returns the minutes from now`` some =
        some > 0 ==> (some .Minutes().FromNow = (add some DateTime.Now.AddMinutes))

    [<Property>]
    let ``Returns the days from now`` some =
        some > 0 ==> (some .Days().FromNow.Date = (add some DateTime.Today.AddDays |> toDate))

    [<Property>]
    let ``Returns the years from now`` some =
        some > 0 ==> (some .Years().FromNow.Date = (some |> DateTime.Now.AddYears |> toDate))

    [<Property>]
    let ``Returns the months from now`` some =
        some > 0 ==> (some .Months().FromNow.Date = (some |> DateTime.Today.AddMonths |> toDate))

    [<Property>]
    let ``Returns the weeks from now`` some =
        some > 0 ==> (some .Weeks().FromNow = (add (some * 7) DateTime.Now.AddDays))


