﻿namespace RayVE

open RayVE.Math

type Color(red, green, blue) =
    inherit Vector([| red; green; blue |])

    member __.R
        with get() = __.Values.[0]

    member __.G
        with get() = __.Values.[1]

    member __.B
        with get() = __.Values.[2]

    member __.ToPPM maxValue =
        [| __.R; __.G; __.B |]
        |> Array.map (Color.GetPPMValue 255)
        |> Array.map (sprintf "%i")

    static member GetPPMValue maxValue rawValue =
        rawValue * double(maxValue)
        |> round
        |> int
        |> clamp 0 maxValue

    static member (*) (left: Color, right: Color) =
        let values = Array.map2 (*) left.Values right.Values
        Color(values.[0], values.[1], values.[2])

    static member Black
        with get() = Color(0.0, 0.0, 0.0)

    static member White
        with get() = Color(1.0, 1.0, 1.0)

    static member Red
        with get() = Color(1.0, 0.0, 0.0)

    static member Green
        with get() = Color(0.0, 1.0, 0.0)

    static member Blue
        with get() = Color(0.0, 0.0, 1.0)

    static member Cyan
        with get() = Color(0.0, 1.0, 1.0)

    static member Magenta
        with get() = Color(1.0, 0.0, 1.0)

    static member Yellow
        with get() = Color(1.0, 1.0, 0.0)