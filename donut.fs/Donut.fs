open System

let isUnix =
    match Environment.OSVersion.Platform with
    | PlatformID.Unix -> true
    | _ -> false

let mutable k = 0.0
let mutable A = 0.0
let mutable B = 0.0

let sin (x: float) = Math.Sin(x)

let cos (x: float) = Math.Cos(x)

let main () =
    let z = Array.zeroCreate<float> 7040
    let b = Array.zeroCreate<char> 1760

    if isUnix then
        Console.Write("\x1b[2J")
    else
        Console.CursorVisible <- false

    while true do
        Array.fill b 0 1760 ' '
        Array.fill z 0 7040 0.0

        for j: float in 0.0..0.07..6.28 do
            for i: float in 0.0..0.02..6.28 do
                let c = sin i
                let d = cos j
                let e = sin A
                let f = sin j
                let g = cos A
                let h = d + 2.0
                let D = 1.0 / (c * h * e + f * g + 5.0)
                let l = cos i
                let m = cos B
                let n = sin B
                let t = c * h * g - f * e
                let x = 40 + int (30.0 * D * (l * h * m - t * n))
                let y = 12 + int (15.0 * D * (l * h * n + t * m))
                let o = x + 80 * y
                let N = 8.0 * ((f * e - c * d * g) * m - c * d * e - f * g - l * d * n)

                if 22 >= y && y > 0 && 0 <= x && x < 80 && D > z.[o] && o >= 0 && o < 1760 then
                    z.[o] <- D
                    b.[o] <- ".,-~:;=!*#$@".[if int N > 0 then int N else 0]

        Console.SetCursorPosition(0, 0)

        for i = 0 to 1760 do
            if i % 80 <> 0 then
                Console.Write(b.[i])
            else
                Console.WriteLine()

        A <- A + 0.04
        B <- B + 0.02

main ()
