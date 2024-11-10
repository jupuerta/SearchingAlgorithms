let cont = 0;
let GridColoredSquare = []; // Arreglo para almacenar las coordenadas y colores.

function paintSquare(element) {
    let row = element.dataset.row;
    let col = element.dataset.col;

    console.log(row);
    console.log(col);

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
    listNodes.listPathChoosen.forEach((nodo, index) => {
        if (index !== 0 && index !== listNodes.length -1) {
            let element = document.querySelector(`.grid-item[data-row="${nodo.x}"][data-col="${nodo.y}"]`);
            element.style.backgroundColor = "blue";
            console.log(index)
        }
    });

    listNodes.listNodeRevised.forEach((nodo, index) => {
        let element = document.querySelector(`.grid-item[data-row="${nodo.x}"][data-col="${nodo.y}"]`);
        element.style.backgroundColor = "gray";
        console.log(index)
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

