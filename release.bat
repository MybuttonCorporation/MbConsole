@echo off
git add .
git commit -m "%*"
git push -u origin main
echo released & published to github (MybuttonCorporation/MbConsole)
