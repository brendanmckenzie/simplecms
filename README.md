SimpleCms
=========

After battling with a few CMS' lately I thought I'd take a crack and see how hard it would be to make a simple, light-weight, easily-extendable CMS.

The idea is that the CMS is a simple tree-based document store where nodes can be documents of various types.  It should also be MVC based.

The administration portal should be completely separate from the front-end, however they should share the database.

The front-end website is essentially stand-alone and relies on the CMS to setup the routing for documents to their associated controller.  When the controller action is executed it's passed a strongly-typed reference to the document being requested.

Each "document" type should be its own entity in the database.  There should be an absolute bare minimum scaffolding in the database from the CMS.