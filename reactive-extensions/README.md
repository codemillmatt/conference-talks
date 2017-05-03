# Rx-Cure
Slides and demo code presented with the Cure What Ails You With This Rx - An Intro To The Reactive Extensions talk. Presented at CodeMash on January 8, 2016.

# Demos
1. The first demo centered around calling a simulated web service to provide a list of words that contained letters entered into a search box. The requirements for this demo (especially only calling the web service once every half second at most) were such that implementing it the imperitative way was not easy and very bug prone. But implementing it with Rx was declarative and matched the requirements exactly - leaving us to focus on the business domain instead of the "plumbing".
2. The second demo showed how to limit the movement of an image on the screen. We used a marble diagram first to figure out which operators we wanted to use, then implemented it.
3. The third demo was a bit more complex and "real-world", but still easy to implement with Rx. Here we are receiving many bluetooth advertisements containing information from sensors located in beehives. Due to the nature of these devices however, they broadcast once every 5 seconds, but only take a new reading once per hour. We do not want to record any data unless we haven't recorded it already - meaning we need to discard a lot of the "every 5 second advertisements". Using marble diagrams and Rx - this was an easy task!

# Resources
The following resources proved useful during the development of this talk:
* http://www.introtorx.com
* http://reactivex.io
* https://channel9.msdn.com/Series/Rx-Workshop
* http://reactivex.io/learnrx/
* https://github.com/Reactive-Extensions/Rx.NET
* http://rxmarbles.com/
* https://gist.github.com/staltz/868e7e9bc2a7b8c1f754
