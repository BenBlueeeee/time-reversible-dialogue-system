# time-reversible-dialogue-system

a dialogue system that can be run both forwards and backwards in time

This is designed exclusively for use within the inversion project (and may indeed be coupled with its code in some places, although ideally not). This code is not designed to be useful as a general dialogue system, although it may be adaptable and useful for other projects with some work.

# .dialogue File conventions / structure

- line 0 is the line that says "START"
- END will end the dialogue at any point in the speech (this implies that the last line of the document should be an "END": if this is not the case then the program will append "END" as the last line before doing anything else)
- 

# Conventions

## Commit Types

- **`feat`**: A new feature  
- **`fix`**: A bug fix  
- **`docs`**: Documentation-only changes
- **`notes`**: Adding dev-notes / diary entries
- **`style`**: Code style changes (whitespace, formatting, etc. — no code behavior change)  
- **`refactor`**: A code change that neither fixes a bug nor adds a feature  
- **`perf`**: A code change that improves performance  
- **`test`**: Adding or correcting tests  
- **`build`**: Changes to the build system or dependencies (e.g. npm, Makefile)  
- **`ci`**: Changes to CI configuration or scripts (e.g. GitHub Actions, Travis)
- **`chore`**: General maintenance tasks not related to features, fixes, docs, or build

## Branch Names

Branch names can follow the same names, but are formatted like
- **`feat/adding-x-from-y`**
- **`fix-enemymeshes/removing-extraneous-faces`**

(as **`:`**, **`()`** etc would have to be escaped and branch names cannot have whitespace.)

## Example Messages

```bash
feat(bvh): implement initial bounding volume hierarchy generation
fix(plot): correct axis scaling in star visualisation
docs: update README with usage instructions
build: update python_requirements.txt
chore: remove .vscode folder from git tracking (cache)
```

## Sources

This project follows the [Conventional Commits specification v1.0.0](https://www.conventionalcommits.org/en/v1.0.0/#summary).

Some of the commit types listed above are from the [Angular Commit Message Guidelines](https://github.com/angular/angular/blob/22b96b9/CONTRIBUTING.md#-commit-message-guidelines). That link also gives some general guidelines for message formatting that I think are nice.