Todo
----

+ Completely redesign interface in better OO-manner

```
var fake = new Fake<IAdder>();

// Moq-inspired mock companion object
var obj = fake.Object;

// Companion object for each stubbed method
Stub<int> addOne = mug.Stub(obj => obj.AddOne, (int i) => i + 2);

// Decent no-magic-involved call counting
addOneStub.CallCount.ShouldBe(5);

// Filters on call data
addOneStub.Calls.Where(c => c.First < 6).Count().ShouldBe(7);
```    

* Allow LINQ'ing over all calls, in order

```
fake.Calls.Last().Arguments.Length.ShouldBe(5)
fake.Calls.Last().Arguments[1].ShouldBe(true); // Arguments is an object[]
```

* Include timestamp with calls
* Be thread-safe with adding calls.
