Our Philosophy
===
***CVNA-SCHED-FND-004***

***Aug 2022***

---

## Releases

***Release often and with confidence.***

* Every approved evolution of the code base should be a tested and Production deployable unit of work.

* As such every PR can be sent straight to the Master branch where it will undergo the current Unit, Integration, Acceptance and may subsequently undergo Load Testing as part of the release pipeline.

* Upon passing all tests the evolution is staged for final deployment to Production and can be initiated upon approval.

## A Pragmatic Approach
---

Even with best tests and alerting in place, releasing still has its risks. As a Tier 1 team supporting Carvana, downtime has a large impact on core Carvana Business. 

As such we’ve restricted Production releases on Friday, Saturday and Sunday to only those releases that are business critical.

## Daily Execution
---
### **Feature Development Steps**

Every standard evolution of code begins as a feature branch off the current head of master branch. 
Prior to Pull Request the feature branch is deployed to the NonProd environment for any necessary validation and may undergo specific Load Testing via UATOnly deployment. (See Carvana Azure DevOps Pipelines)
Once engineering evaluation is complete the evolution is under review via Pull Request and automated testing accompanied by a link to the Pull Request posted in #sched-pr.
Once the Pull Request to master is approved the latest evolution is staged in UAT and may undergo additional Load Testing on K6.
Once the engineer responsible for the evolution is ready to promote to production a post with the link to the specific Release is posted in #sched-pr. (See for example carvana-mktops-scheduling)
Upon release to Production the stability of the release should be confirmed by the responsible engineer.

### **Branch Naming Standards**

* New Feature
    * /minor/{storyId}/{storyTitle} (e.g., minor/SCHED-624/imAnewFeature)
    * Bumps **Minor** version
* Tech Debt/Refactor/Reorganization
    * /patch/{storyId}/{storyTitle} (e.g., patch/SCHED-625/aLittleTweak)
    * Bumps **Patch** version
* Bug
    * bug/{bugId}/{bugTitle}
    * Bumps **Patch** version
* HotFix
    * /hotfix/mm_dd_yyyy/{titleThePain}
    * Bumps **Patch** version

### **Pull Request Completion Checklist**

Azure Dev Ops pull request policy is managed by our DevOps team. As of March 2022, it requires any engineer to approve for the PR to be completed.

#### **How did we test it?**

Note: Select all that apply knowing that not all are required for every evolution.

- [ ] Covered with automated tests
- [ ] NonProd Engineer validation
- [ ] Product Manager validation
- [ ] QE Validated
- [ ] Not Applicaplicable

#### **Engineers' Sanity Check**

- [ ] Measure twice cut once
- [ ] All tests pass locally
- [ ] Latest `master` included
Squash Commit. This is to keep our source repository history to a minimum.
Delete source branch. This is to keep the branch list clean of stale branches.