$(".table-td").click(function () {
    $(this).toggleClass("clicked")
    var tags = $("[class=clicked]")
    console.log(tags[0])       
    
    //$.post("demo_test_post.asp",{name: "Donald Duck",city: "Duckburg"},function (data, status) {alert("Data: " + data + "\nStatus: " + status);});

 });