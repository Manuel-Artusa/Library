const urlAutor = "https://localhost:7129/api/Autor"
function listarAutores(){
    fetch(urlAutor)
        .then((response) => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then((autores) => {
            const cuerpoTabla = document.querySelector('tbody');
            cuerpoTabla.innerHTML = "";
            autores.forEach(aut => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${aut.id}</td>
                    <td>${aut.nombre}</td>
                    <td>${aut.fec_Nac}</td>
                    <td>
                        <button class="btn btn-primary btn-sm" onclick="editarAutor(${aut.id})">Editar</button>
                    </td>
                `;
                cuerpoTabla.appendChild(row);
            });
        })
        .catch((error) => {
            console.error("Error al obtener autores:", error);
            alert("Error al obtener autores");
        });
    
}
function editarAutor(id) {
    window.location.href = `formautor.html?id=${id}`;
}