module MavenThought.Epoch.Tests.``Date range tests``

open System
open FsCheck
open FsCheck.NUnit
open System.Linq
open MavenThought.Epoch

let mkRange (sd:DateTime) (ed: DateTime) = DateRange(sd, ed)

module ``Constructor using dates`` =

    [<Property>]
    let ``Creates a date range with start and end`` (sd:DateTime) (ed: DateTime) =
        (ed > sd) ==> lazy (
            let range = mkRange sd ed
            range.StartDate = sd.Date && range.EndDate = ed.Date
        )

module ``Constructor using span`` =

    [<Property>]
    let ``Creates a date range with the specified span`` (sd:DateTime) (span: int) =
        (span > 1) ==> lazy (
            let range = DateRange(sd, span .Days().Span)
            range.StartDate = sd.Date && range.EndDate = (sd.Date + TimeSpan(span, 0, 0, 0))
        )

        
module ``#GetEnumerator method`` =
    let rec allDatesBetween (startDate:DateTime) (endDate:DateTime) = seq { 
        if startDate.Date <= endDate.Date then
            yield startDate.Date
            yield! allDatesBetween (startDate.Date.AddDays(1.0)) endDate
    }

    let haveSameElements seq1 seq2 = Enumerable.SequenceEqual(seq1, seq2)

    [<Property>]
    let ``Returns all the dates in the range`` (sd:DateTime) (ed: DateTime) =
        (ed > sd) ==> lazy (haveSameElements (mkRange sd ed) (allDatesBetween sd ed))


module ``#NotInclusive method`` =
    [<Property>]
    let ``Changes the end date to be a day less`` (startDate:DateTime) (endDate: DateTime) =
        let notInc () = (mkRange startDate endDate).NotInclusive
        (endDate > startDate) ==> lazy (notInc().EndDate = endDate.Date.AddDays(-1.0))


module ``#Includes method`` =
    module ``When the date is part of the range`` =
        [<Property>]
        let ``Returns the date is included`` (sd:DateTime) (ed: DateTime) (aDate: DateTime) =
            (ed > sd && aDate >= sd && aDate <= ed) ==> (mkRange sd ed).Includes(aDate)

    module ``When the date is not part of the range`` =
        [<Property>]
        let ``Returns the date is NOT included`` (sd:DateTime) (ed: DateTime) (aDate: DateTime) =
            (ed > sd && (aDate < sd || aDate > ed)) ==> not ((mkRange sd ed).Includes(aDate))
