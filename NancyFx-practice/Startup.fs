namespace NancyFx_practice.Web.Config

open Microsoft.AspNetCore.Builder
open Nancy.Owin

type Startup() =
    member this.Configure(app: IApplicationBuilder) =
        app.UseOwin(fun x -> x.UseNancy() |> ignore ) |> ignore