# Fix: AZ7ud83Q7oTRF9lfUdEv

## Pattern
S2376 write-only property → add getter

## Change
```diff
- internal IPlayer PlayerForTest { set { player = value; } }
+ internal IPlayer PlayerForTest { get => player; set => player = value; }
```

## File
AudioSource.cs:59
