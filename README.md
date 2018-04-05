# Autodraw

A simple program that draws given image in MS paint pixel by pixel.

## How to make it work?

Download the code as Zip. Extract the code and run it. This will automatically launch MS Paint and start draw the image given as 
```
image.jpg
```

:exclamation: Use smaller images, like 100*100. It takes awfully long time to complete. Still not optimized :P

## Working with git

### Step 1: Create a repo in Git

```
https://github.com/new
```

### Step 2: Initialize git in the local folder

Execute the following command git cmd to init git on the local sytem folder

```
git init
```

### Step 3: Add remote git repo create earlier

Execute the following command git cmd to link remote repo to local system folder

```
git remote add origin https://github.com/<user>/<repo-name>.git
``` 

### Step 4: Pull initial changes from repo

Execute the following command git cmd to get changes from repo

```
git pull origin master
```

### Step 5: Add files to the local repo

This will add all files to repo

```
git add .
```

### Step 6: Commit changes to repo

```
git commit -m "<your-message>"
```

### Step 7: Push local changes to remote repo

```
git push -u origin master
```

### Git Status

To see the status of the current local repo

```
git status
```


