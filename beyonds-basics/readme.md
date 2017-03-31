# Going Beyond the Basics with Xamarin.Forms

Given at:
* Indy.Code() - March 30, 2017

## Abstract
At the heart of a great Xamarin.Forms mobile app is the ability to customize the user experience and shorten development time with reusable components. In this session, you will learn the skills to create high quality, robust, and beautiful apps all the while creating an arsenal of reusable components. You will learn how to extend Xamarin.Forms controls beyond their built-in abilities; how to style user interfaces, display dynamic data within lists and build complex layouts with grids; you’ll even learn how to integrate native controls right into the shared code layer. When you’re finished with this session, you’ll have the knowledge of Xamarin.Forms necessary to create fantastic apps in the real world.

## Demos
1. __Behaviors__ - in this demo we explored how behaviors added functionality to a control without having to subclass the control. Some important things to notice are how the control being acted on is passed into the `OnAttachedTo` and `OnDetachingFrom` functions. This lets you setup event handlers on the control in question to add the additional _behavior_ to it.

2. DataTemplateSelectors - these are slick! They give a `ListView` the ability to diplay more than one cell type. The `RecipeDataTemplateSelector` does the work for us here. Notice the 2 `DataTemplates` are only being instantiated in the constructor and then held as class level variables. The `DataTemplate`s are initialized with the type of `ViewCell` they will display. Then within the `OnSelectTemplate` function - the correct template is selected based off the `item` parameter. That parameter happens to be an individual item class the `ListView` is bound to.

3. Styles - In this demo you saw how app themeing can be achieved through the clever use of styles. Everything is occuring with the     `RecommendedRecipeCell` class. All of the controls are set to a style that has not been declared elsewhere through the use of the `DynamicResource` keyword. Then in the code-behind, the key the `DynamicResource` was set to is set to be equal to a style that is defined within the app.

4. Effects and Native Views - The key to this demo, other than the actual creation of the effect in the platform project, is to create a `RoutingEffect` in the core project. This class will subclass `RoutingEffect` and then in the base constructor pass in the `ResolutionGroupName` and the `EffectName` (both of which are defined in the platform project). That `RoutingEffect` can then be accessed from XAML, and added to the control's `Effects` collection.