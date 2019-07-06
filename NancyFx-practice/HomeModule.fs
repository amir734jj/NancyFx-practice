
namespace NancyFx_practice.Web.Modules
open Nancy
open System
open System.IO
open System.Text

type Person() =
    member val Age = 0 with get, set
    member val Name = String.Empty with get, set

module StreamExtensionModule =
    open Newtonsoft.Json

    type Stream with
        member this.Bind<'T> () =
            use result = new StreamReader(this, Encoding.UTF8)
            JsonConvert.DeserializeObject<'T>(result.ReadToEnd())

    type HomeModule() as this =
        inherit NancyModule()

        do        
            this.Get("/hello", fun (parameters) ->
                async {
                    return "bar" :> obj
                }  |> Async.RunSynchronously)
            
            this.Get("/{name}", fun (parameters) ->
                let name = (parameters :?> Nancy.DynamicDictionary).["name"]
                name)

            this.Post("/", fun (parameters) ->
                let person = this.Context.Request.Body.Bind<Person>()
                person
                :> obj)
