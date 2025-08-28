# ImageProcessingFramework
 ImageProcessingFramework
This project implements a basic image processing framework in .Net applications
The main advantage of this implementation is that the plugins can be added with json configuration files, which will be picked up by the pluginregistry using reflection to dynamically load the dll files.
Plugin registry handles the logic for adding all the available plugins, the plugins themselves are adhering to OOP principles, they're not concrete implementations and if needed adapter pattern can solve incompatibility issues with new or old plugins.