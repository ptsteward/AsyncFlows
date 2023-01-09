Ticket Priorities & Severities
===
***CVNA-SCHED-FND-0053***

***Aug 2022***

---

## Jira Defined Priorities
### **Product Priority**

The Consumer always comes first and foremost. A Product Priority describes the relative Value and Urgency of the evolution as it relates to the Consumer. Product Priority may become higher than any Sprint Goal if it yields a great deal of Value with Urgency.

Product Priority is a complementary component of the Jira Rank and is defined by its Intended and Targeted completion amongst Sprints.

*Intended* - Where amongst Sprints, Product and Engineering leadership, are attempting to place the Ticket

*Target* - Where amongst Sprints, Product and Engineering leadership, determine the Ticket must be completed

**Product Priority**, as defined within Jira, is broken into P increments.
- **P0 - Urgent, High Value Evolution**
  - Bring into Active Sprint
  - Higher Priority than Sprint Goal
- **P1 - Up Next, High Value Evolution**
  - Targeted and intended for the next Sprint
- **P2 - Up Next, Valuable Evolution**
  - Intended for the next Sprint
  - Targeted within next Month
- **P3 - Known, Valuable Evolution**
  - Intended as time allows
  - Targeted for End of Quarter

### **Engineering Priority**

Engineering Priority is driven by the Requirements, Sustainability and Advancement of the underlying technical ecosystem that ultimately yields Product Value.
- **Highest - Overrides Active Sprint priorities**
  - Represents Urgent and Necessary Engineering Value
- **High - Represents a fundamental and/or necessary Evolution of the ecosystem**
  - Groundwork for eventual Value, without which the Value would not meet Engineering Rigor standards 
  - Represents what comes first amongst the Sprint work load
  - Sprint Goal
- **Medium - Represents the next phase of delivering Value and/or the next layer of Evolution within the ecosystem**
  - Supporting structure for eventual Value, without which the Value would not meet Engineering Rigor standards 
  - Represents the up next priority amongst the Sprint work load
  - Relevant Engineering to improve functionality of the current systems
  - Sprint Expectation notwithstanding unexpected complexity or problems with anything High/Highest
- **Low - Represents narrow use case Value and/or an Evolution without a direct enabling guide toward Value**
  - Relevant Maintenance to continue functionality of the current systems
  - Represents the first line of Tickets to be shifted if a P0/Highest is brought in or other complexity or problems come up

---

## Response Severities
### **Team Defined Severities**
- **Severity 0 - This is the highest Severity**
  - Reserved for active War Rooms
  - An active War Room that has no corresponding Severity 1 Alert in #sched-alerts indicates that there is a missing alert vector
- **Severity 1 - First line notice of to act prior to escalation to War Room**
  - Posts a notification to #sched-alerts and trigger a VO Alert 
  - This expansive notification strategy is intended to ensure On Call Engineers are notified of the issue and can prior to an escalation
- **Severity 2 - At this level an escalation to a War Room is considered impossible unless a blind spot in Alerting is identified**
  - Indicates there may be a functional abnormality with the deployed Production system 
  - Identifies what transforms into P2/Medium Jira Ticket
  - This Severity primarily applies to Ad-Hoc Request as defined within {section}
- **Severity 3 - This Severity is well beyond the possibility of War Room escalation encompassed by Severity 2**
  - Indicates there may be a functional or configuration abnormality with the deployed Production system
  - Identifies what transforms into P3/Medium Jira Ticket
  - This Severity primarily applies to Ad-Hoc Request as defined within {section}


![Priorties Alignment](/.attachments/priorities-chart.png =750x)
