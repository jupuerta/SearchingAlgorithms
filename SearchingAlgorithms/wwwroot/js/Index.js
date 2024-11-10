let cont = 0;
let GridColoredSquare = [];
let isMouseDown = false;

function ResetAll() {
    cont = 0;
    GridColoredSquare = [];
    document.querySelectorAll(".grid-item").forEach(elem => {
        elem.style.backgroundColor = "lightgray";
    });
}

function PaintSquare(element) {
    let row = element.dataset.row;
    let col = element.dataset.col;

    if (cont === 0) {
        cont = cont + 1;
        element.style.backgroundColor = "red";
        GridColoredSquare.push({ X: row, Y: col, Detail: "begin" });
        return;
    }
    if (cont === 1) {
        cont = cont + 1;
        element.style.backgroundColor = "green";
        GridColoredSquare.push({ X: row, Y: col, Detail: "end" });
        return;
    }
}
function PaintPath(listNodes) {

    console.log(listNodes)

    listNodes.listNodeRevised.forEach((nodo, index) => {
        let element = document.querySelector(`.grid-item[data-row="${nodo.x}"][data-col="${nodo.y}"]`);
        element.style.backgroundColor = "lightblue";
    });

    listNodes.listPathChoosen.forEach((nodo, index) => {
        if (index !== 0 && index !== listNodes.length -1) {
            let element = document.querySelector(`.grid-item[data-row="${nodo.x}"][data-col="${nodo.y}"]`);
            console.log(`x:"${nodo.x}" y:"${nodo.y}"`)
            element.style.backgroundColor = "blue";
        }
    });
}

document.getElementById('submitData').addEventListener('click', () => {
    fetch('/DetallePathFollow', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(GridColoredSquare)
    })
        .then(response => response.json())
        .then(data => PaintPath(data))
        .catch(error => console.error('Error:', error));
});

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
            elem.style.backgroundColor = "black";
            GridColoredSquare.push({ X: elem.dataset.row, Y: elem.dataset.col, Detail: "barrier" });
            console.log(GridColoredSquare);
        }
    });
});