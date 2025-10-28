# charanim
jump animation parameter is trigger
run and idle are bool type parameter

if moving  by velocityapi
    do the run animation
input.keydown to keyboard key move 


### From **Idle → Run**
- **Condition:** `run == true`
- **Has Exit Time:** Off  
- **Transition Duration:** Short (0.1 sec recommended)

### From **Run → Idle**
- **Condition:** `run == false`
- **Has Exit Time:**  Off  
- **Transition Duration:** Short (0.1 sec recommended)

### From **Any State → Jump**
- **Condition:** `jump` (Trigger)
- **Has Exit Time:**  Off  
- **Fixed Duration:** Off

### From **Jump → Idle**
- **Condition:** idle
  
