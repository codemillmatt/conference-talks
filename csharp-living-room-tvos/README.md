# As Seen On TV ... Bringing C# to the Living Room
## An Intro to tvOS Development with Xamarin
### Xamarin Evolve 2016

Slides, demo code and references from April 27, 2016 talk at Xamarin Evolve on tvOS development.

### Demos
* HelloEvolve
    * Simple hello world to give an overall idea of how tvOS projects are laid out in Xamarin Studio.
    * Storyboards, XCode Interface Builder or pure code can be used to build the UI.
    * In the code here, a primary action triggered event is wired up through a storyboard and through C#.
    * A Siri remote "up-arrow" touch event is also shown.
    * __Remember to show the remote!__ :)
    
* OrganizationDemo
    * This is the demo that shows some of the APIs that the focus engine exposes.
    * The `FocusImage` enables image views to become focusable elements.
    * Take a look at some of the overrides within `CheeseDetailController` they provide some additional "pizazz" to the UI.
    * The `CheeseDetailController.PreferredFocusedView` controls what initially has focus on a focus update - now the WEDGE OF APPROVAL has the focus.
    * On the storyboards, if you put the buttons into a stackview - you can easily account for some appearing and disappearing.
       * Note: If you do add a stackview, the storyboard editor in Xamarin Studio will stop working (at least in beta). It'll still load and work fine in XCode.
    
### References
* [Apple TV Dev Talks](https://developer.apple.com/videos/techtalks-apple-tv/)
* [Xamarin tvOS Documentation](https://developer.xamarin.com/guides/ios/tvos/)
* [tvOS Programming Guide](https://developer.apple.com/library/tvos/documentation/General/Conceptual/AppleTV_PG/)
* [tvOS Human Interface Guidelines](https://developer.apple.com/tvos/human-interface-guidelines/)


A big thank you for everybody attending! Please reach out if you have any questions!
