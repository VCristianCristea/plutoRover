# Pluto Rover API
Pluto Rover API is a WebAPI that is used to coordinate the rover from planet Pluto trough commands.

## Development Pre-requisites and Tech stack

This application is using the following libraries:
  * .NET Core 3.1
  * xUnit Framework ( for unit testing ) 
  * NSubstitute
  * FluentAssertions

## Business Case
After NASA’s New Horizon successfully flew past Pluto, they now plan to land a Pluto Rover
to further investigate the surface. Pluto Rover API is responsible to move the Rover around the planet. 

The planet is divided up into a grid. The rover's position and location is represented by a combination of x and y coordinates and a letter representing
one of the four cardinal compass points. 

An example position might be 0, 0, N, which
means the rover is in the bottom left corner and facing North. Assume that the square
directly North from ( x, y ) is ( x, y+1 ).

On planet it is supposed to exists some obstacles so before each move to a new position. If a given sequence of commands encounters an obstacle, the rover moves up to the last
possible point and reports the obstacle. ( Should make a request to get the latest position )

## APIs

### PUT v1/api/rover/move
This is the endpoint which is called in roder to move the rover through a set o commands.

### Available commands:
  * F - Move Forward (increase x or y position with 1)
  * B - Move Backward (decrease x or y position with 1)
  * L - Rotate Left (rotate 90 degrees **left** from it's current direction)
  * R - Rotate Right (rotate 90 degrees **right** from it's current direction)


Example request:

```shell
curl -X PUT "https://localhost:44324/v1/api/rover/move" -H "accept: application/json" -H "Content-Type: application/json-patch+json" -d "{\"instructions\": \"FFRFF\"}"
```

```json
{
  "instructions" : "FFRFF"
}
```

Example response:

```json
{
  "roverPosition": {
    "posX": 2,
    "posY": 2
  },
  "facingDirection": {
    "cardinalPoint": "E"
  }
}
```


## Point Of Contact
> VCristian.Cristea at gmail.com

