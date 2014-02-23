
var thumbnailHolder = document.getElementById("thumbnailBox");
var numbrOfThumbNails = thumbnailHolder.children.length;

document.getElementById(localStorage.markedOne).children[0].className = "marked";

for (var i = 0; i < numbrOfThumbNails; i++){


    thumbnailHolder.children[i].onclick = function (e) {

        e.target.className = "marked";

        localStorage["markedOne"] = e.target.parentElement.id;


    }

}