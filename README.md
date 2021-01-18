# ejectory
A puzzle game based around manipulating trajectories.


Dev Workflow:

1. Creating a branch for a specific issue.
Use the following name convention for branch naming:
`<nickname>/<issue-name>`
2. Commit & push changes normally, and make sure to merge any conflicts.
3. Open a pull request (PR) and get someone to approve it
4. Once approved, you can merge into `main` and delete your branch.\
\
See below code for the appropriate git commands:

    ```
    # Start on some branch (typically main)
    # (you can check what branch you're on with git branch)
    # Create your branch with
    git checkout -b <nickname>/<issue-name>

    # Make changes and commit appropriate files
    # Add files to commit
    git add <files> (use "git add ." to add all changed files)
    # Commit with short descriptive message
    git commit -m "message describing your changes"

    # When ready to open a PR
    git push

    # From here, go to the repository website -> Pull Requests -> New Pull Request to open your PR.
    ```
