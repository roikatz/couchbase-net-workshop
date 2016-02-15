#Developing with Couchbase and it's 2.x Net SDK

##Requirements

For the first day the following needs to be prepared:

* 3 VM-s with CentOS 6
* Static IP addresses
* A ping between the VM-s needs to be possible

For the second workshop days the following is required:

* A Microsoft development environment aka Windows 
* An IDE - Visual Studio (VS2015 with framework 4.6 recommemded)
* Git client
For both days internet access is required in order to get access to the workshop code repository and other resources.

Please see the file [VMSetup](https://github.com/dmaier-couchbase/cb-workshop/blob/master/VMSetup.md) for further details!

##Agenda
* Day 1

Time |Title
-----|-----
9:00 |Introduction and Core Use Cases
     |Couchbase Server Architecture
     |Couchbase Server as a Distributed System
10:30|Coffee Break
     |Working with Buckets
     |Working with the Cluster
12:30|Lunch
     |Security
     |Cross Data Center Replication explained
17:00|Q&A and Summary

* Day 2

Time |Title
-----|-----
9:00 |Document Modelling Basics
     |Querying via Views
     |TPL and async await pattern
10:30|Coffee Break
     |The 2.x .Net API
12:30|Lunch
     |Hands-on
     |Specific Use Case presentation
17:00|Q&A and Summary, What's new in 4.0

#Excercises
#Day 1: Couchbase Architecture and Administration Basics


| # | Title | Content|
|---|---|---|
|1|Installation and Configuration|Disable Swappines
| ||Disable the Linux Firewall
|||Download and Install Couchbase
|||Configure the Cluster
|2|Testing the Installation|List the nodes of your current cluster
|||Investigate the data and index directory
|||Get some data from a vBucket file
|||Get some info about a vBucket file
|||Install Telnet
|||Retrieve some statistics via Telnet
|||Set/get a value via Telnet
|||Install Curl
|||Get details via the REST API
|3|Working with Buckets|Create a Bucket via the UI
|||Add a document to the Bucket
|||Create a Bucket via the CLI
|4|Working with the Cluster|Add/remove nodes via the UI
|||Rebalance
|||Add/remove nodes via the CLI
|5|Backup/Restore|Use cbbackup to backup a Bucket
|||Use cbrestore to restore to another Bucket
|6|XDCR|Create an XDCR link via the UI

# Day 2: Using the Couchbase .Net 2.x Client Library

The starting point for the day 2 execises is the cb-workshop-starter project. This is basically an empty application skeleton. Folder cb-workshop-starter-adv is a bit more progressed. The final solution can be found in folder cb-workshop.

|#|Title|Content
|---|---|---|
|7|Project Setup|Nuget manager Dependecies
|8|Connection Management|ConnectionFactory, Singleton approach
|9|CRUD Operations|Create Documents|Reference Documents|Get Documents
|10|Querying via Views|Create a Design Document, Create View, Query via the Browser and Client
|11|Querying via N1QL|Create a Secondary Index via the CLI, A simple Query, Query by performing a Join


     
