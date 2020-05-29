# Creating Entities
For creating entities you need to run world.AddEntity().
Names are used for Editor debug information only, so they are optional.
```csharp
var entity = this.world.AddEntity([name]); // The same as var entity = new Entity(name);
...
```