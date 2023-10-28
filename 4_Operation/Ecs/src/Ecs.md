# Entity Component System

## Entity: 

An entity represents a general-purpose object. In a game engine context, for example, every coarse game object is represented as an entity. Usually, it only consists of a unique id. Implementations typically use a plain integer for this.

## Component: 

A component labels an entity as possessing a particular aspect, and holds the data needed to model that aspect. For example, every game object that can take damage might have a Health component associated with its entity. Implementations typically use structs, classes, or associative arrays.

## System: 

A system is a process which acts on all entities with the desired components. For example, a physics system may query for entities having mass, velocity and position components, and iterate over the results doing physics calculations on the sets of components for each entity.