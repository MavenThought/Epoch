module MavenThought.Epoch.Tests.``Date Creation Tests Using On Month``   

open System
open FsCheck
open FsCheck.NUnit
open MavenThought.Epoch 

[<AutoOpen>]
module Config =
    let currentYear = DateTime.Today.Year
    let dayInRange top day = day > 0 && day <= top
    let mkDate year month day = DateTime(year, month, day)
    let matchMonth month = match month with
                            | 01 -> On.Jan, 31
                            | 02 -> On.Feb, 28
                            | 03 -> On.Mar, 31
                            | 04 -> On.Apr, 30
                            | 05 -> On.May, 31
                            | 06 -> On.Jun, 30
                            | 07 -> On.Jul, 31
                            | 08 -> On.Aug, 31
                            | 09 -> On.Sep, 30
                            | 10 -> On.Oct, 31
                            | 11 -> On.Nov, 30
                            | 12 -> On.Dec, 31
                            | _  -> On.Jul, 31

module ``When called with default year`` =
    let createDates month day =
        let monthFn, top = matchMonth month
        dayInRange top day ==> lazy (monthFn(day) = mkDate currentYear month day)

    [<Property>]
    let ``Creates all dates in Jan`` (day:int) = createDates 01 day

    [<Property>]
    let ``Creates all dates in Feb`` (day:int) = createDates 02 day

    [<Property>]
    let ``Creates all dates in Mar`` (day:int) = createDates 03 day

    [<Property>]
    let ``Creates all dates in Apr`` (day:int) = createDates 04 day

    [<Property>]
    let ``Creates all dates in May`` (day:int) = createDates 05 day

    [<Property>]
    let ``Creates all dates in Jun`` (day:int) = createDates 06 day

    [<Property>]
    let ``Creates all dates in Jul`` (day:int) = createDates 07 day

    [<Property>]
    let ``Creates all dates in Aug`` (day:int) = createDates 08 day

    [<Property>]
    let ``Creates all dates in Sep`` (day:int) = createDates 09 day

    [<Property>]
    let ``Creates all dates in Oct`` (day:int) = createDates 10 day

    [<Property>]
    let ``Creates all dates in Nov`` (day:int) = createDates 11 day

    [<Property>]
    let ``Creates all dates in Dec`` (day:int) = createDates 12 day

module ``When called with a specific year`` =
    let year =  Nullable(2013)
    let mkDate month day = DateTime(year.Value, month, day)

    [<Property>]
    let ``Creates all dates in Jan`` day = 
        dayInRange 31 day ==> lazy (On.Jan(day, year) = mkDate 01 day)
            
    [<Property>]
    let ``Creates all dates in Feb`` day = 
        dayInRange 28 day ==> lazy (On.Feb(day, year) = mkDate 02 day)

    [<Property>]
    let ``Creates all dates in Mar`` day = 
        dayInRange 31 day ==> lazy (On.Mar(day, year) = mkDate 03 day)

    [<Property>]
    let ``Creates all dates in Apr`` day = 
        dayInRange 30 day ==> lazy (On.Apr(day, year) = mkDate 04 day)

    [<Property>]
    let ``Creates all dates in May`` day = 
        dayInRange 31 day ==> lazy (On.May(day, year) = mkDate 05 day)

    [<Property>]
    let ``Creates all dates in Jun`` day = 
        dayInRange 30 day ==> lazy (On.Jun(day, year) = mkDate 06 day)

    [<Property>]
    let ``Creates all dates in Jul`` day = 
        dayInRange 31 day ==> lazy (On.Jul(day, year) = mkDate 07 day)

    [<Property>]
    let ``Creates all dates in Aug`` day = 
        dayInRange 31 day ==> lazy (On.Aug(day, year) = mkDate 08 day)

    [<Property>]
    let ``Creates all dates in Sep`` day = 
        dayInRange 30 day ==> lazy (On.Sep(day, year) = mkDate 09 day)

    [<Property>]
    let ``Creates all dates in Oct`` day = 
        dayInRange 31 day ==> lazy (On.Oct(day, year) = mkDate 10 day)

    [<Property>]
    let ``Creates all dates in Nov`` day = 
        dayInRange 30 day ==> lazy (On.Nov(day, year) = mkDate 11 day)

    [<Property>]
    let ``Creates all dates in Dec`` day = 
        dayInRange 31 day ==> lazy (On.Dec(day, year) = mkDate 12 day)
    