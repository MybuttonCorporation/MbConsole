@echo off
git add .
git commit -m "%*"
git pull
git push
echo released ^& published to github (MybuttonCorporation/MbConsole)
