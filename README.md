# wooden-typhoon
A 2018 Fall Quarter Project in Unity for the VGDC at UCI.
Inspired by a post on the "Good Bad Ideas" board.

## Goals/Scope
lol idk.

## Workflow!
When testing a prefab not "decorated" by code (aka manually decorating yourself through the editor),
create the prefab, then use GameObject > Break Prefab Instance in the toolbar up top.

## Contributing
Avoid working directly in the master branch, unless its trivial.

To add/edit anything, create a new branch from master.
Then, make the changes, and once its 100% done, merge back into master.

[this](https://www.atlassian.com/git/tutorials/comparing-workflows/feature-branch-workflow) explains it better.
Ideally, master should only have complete commits.

### CLI Users

It's no big deal, but:
* To pull, use `git pull --rebase` to keep the commit history clean.
* To merge, use `git merge --squash` for the same reason.