echo "Merging changes into master: $1"
git checkout master && git merge --no-ff -m "$1" develop && git push && git checkout develop