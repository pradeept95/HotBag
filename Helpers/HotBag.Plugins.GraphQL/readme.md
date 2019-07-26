# Write your query or mutation here
query Query($query : QueryRequestType!){
  test(query: $query) {
    data {
      id
    }
  }
}


## Query Variables
{
  "query" :
  {
    "mode" : "get",
    "query" : {
      "searchText" : "",
      "skip" : "0",
      "maxResultCount" : "10"
    }
  }
}