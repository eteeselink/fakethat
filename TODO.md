Todo
----

* CountCalls for properties
+ Check whether properties are well enough supported now
  + Done! Added StubSetter for set-only properties. Hurray!
* Completely redesign interface in better OO-manner

    mug = new Mug<IAdder>();
    
    // Moq-inspired mock companion object
    var obj = mug.Object;
    
    // Companion object for each stubbed method
    Stub<int> addOne = mug.Stub(obj => obj.AddOne, (int i) => i + 2);
    
    // Decent no-magic-involved call counting
    addOneStub.CallCount.ShouldBe(5);
    
    // Filters on call data
    addOneStub.Calls.Where(calls.First < 6).Count().ShouldBe(7);
    
    
    