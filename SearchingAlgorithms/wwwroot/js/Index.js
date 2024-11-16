let cont = 0;
let GridColoredSquare = [];
let isMouseDown = false;

let colorBegin = "#0d7604";
let colorEnd = "#cb0000";

let colorVisited = "#084fb7";
let colorRevised = "#0d6efd3d";
let colorBarrier = "#000000";

function ResetAll() {
    cont = 0;
    GridColoredSquare = [];
    document.querySelectorAll(".grid-item").forEach(elem => {
        elem.style.backgroundColor = "#cee7e5";
    });
}

function PaintSquare(element) {
    let row = element.dataset.row;
    let col = element.dataset.col;

    if (cont === 0) {
        cont = cont + 1;
        element.style.backgroundColor = colorBegin;
        GridColoredSquare.push({ X: row, Y: col, Detail: "begin" });
        return;
    }
    if (cont === 1) {
        cont = cont + 1;
        element.style.backgroundColor = colorEnd;
        GridColoredSquare.push({ X: row, Y: col, Detail: "end" });
        return;
    }
}
function PaintPath(listNodes) {

    console.log(listNodes.listPathChoosen);

    listNodes.listNodeRevised.forEach((nodo, index) => {
        let element = document.querySelector(`.grid-item[data-row="${nodo.x}"][data-col="${nodo.y}"]`);
        element.style.backgroundColor = colorRevised;
    });

    listNodes.listPathChoosen.forEach((nodo, index) => {
        let element = document.querySelector(`.grid-item[data-row="${nodo.x}"][data-col="${nodo.y}"]`);

        if (index === 0) {
            element.style.backgroundColor = colorBegin;
        } else {
            if (index === listNodes.listPathChoosen.length - 1) {
                element.style.backgroundColor = colorEnd;
            } else {
                element.style.backgroundColor = colorVisited;
            }
        }
        

    });
}

function AjaxCalculatePath(type) {
    fetch('/'+type, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(GridColoredSquare)
    })
    .then(response => response.json())
    .then(data => PaintPath(data))
    .catch(error => console.error('Error:', error));
}

document.getElementById('submitDataAAlgorirm').addEventListener('click', () => {
    AjaxCalculatePath('SubmitDataAAlgorirm');
});

//document.getElementById('submitDataDijkstra').addEventListener('click', () => {
//    AjaxCalculatePath('SubmitDataDijkstra');
//});
document.addEventListener("mousedown", (event) => {
    if (event.button===1) {
        isMouseDown = true;
    }
});

document.addEventListener("mouseup", () => {
    isMouseDown = false;
});

document.querySelectorAll(".grid-item").forEach(elem => {
    elem.addEventListener('mouseenter', () => {
        if (isMouseDown === true) {
            elem.style.backgroundColor = colorBarrier;
            GridColoredSquare.push({ X: elem.dataset.row, Y: elem.dataset.col, Detail: "barrier" });
        }
    });
});