//window.printSection = function (sectionId) {
//    var content = document.getElementById(sectionId).innerHTML;
//    var printWindow = window.open('', '', 'height=900,width=1200');

//    printWindow.document.write('<html><head><title>Print</title>');
//    printWindow.document.write('<style>');
//    printWindow.document.write('@media print {.no-print{display:none;} .print-table{width:100%;border-collapse:collapse;} .print-table th, .print-table td{border:1px solid #000;padding:6px;font-size:12px;} .print-header{text-align:center;margin-bottom:10px;} }');
//    printWindow.document.write('</style>');
//    printWindow.document.write('</head><body >');
//    printWindow.document.write(content);
//    printWindow.document.write('</body></html>');

//    printWindow.document.close();
//    printWindow.focus();
//    printWindow.print();
//    printWindow.close();
//}
//pdf download
window.downloadFileFromBytes = function (fileName, base64Data) {
    const link = document.createElement('a');
    link.href = "data:application/pdf;base64," + base64Data;
    link.download = fileName;
    link.click();
}

//pdf preview
window.openPdfPreview = function (base64Data) {
    if (!base64Data) {
        console.error("Empty PDF data");
        return;
    }

    requestAnimationFrame(() => {
        const byteCharacters = atob(base64Data);
        const byteNumbers = new Array(byteCharacters.length);

        for (let i = 0; i < byteCharacters.length; i++) {
            byteNumbers[i] = byteCharacters.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        const blob = new Blob([byteArray], { type: 'application/pdf' });
        const blobUrl = URL.createObjectURL(blob);

        const win = window.open(blobUrl, '_blank');
        if (win) win.focus();
    });
};
//pdf preview LANDSCAP

window.generateLandscapePdfBase64 = async function (elementId) {
    const element = document.getElementById(elementId);
    if (!element) {
        throw new Error('Element not found: ' + elementId);
    }

    const opt = {
        margin: 10,
        filename: 'stock-register.pdf',
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2, useCORS: true },
        jsPDF: { unit: 'mm', format: 'a4', orientation: 'landscape' }
    };

    // Generate PDF and return as base64
    const pdf = await html2pdf().set(opt).from(element).outputPdf('datauristring');

    // Remove the data:application/pdf;base64, prefix
    return pdf.split(',')[1];
};

// Simple browser print alternative
window.printElement = function (elementId) {
    const element = document.getElementById(elementId);
    const printWindow = window.open('', '', 'height=600,width=800');

    printWindow.document.write('<html><head><title>Print</title>');
    printWindow.document.write('<style>');
    printWindow.document.write('body { font-family: Arial, sans-serif; }');
    printWindow.document.write('table { border-collapse: collapse; width: 100%; }');
    printWindow.document.write('th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }');
    printWindow.document.write('th { background-color: #f2f2f2; }');
    printWindow.document.write('</style>');
    printWindow.document.write('</head><body>');
    printWindow.document.write(element.innerHTML);
    printWindow.document.write('</body></html>');

    printWindow.document.close();
    printWindow.print();
};


//download pdf file for EquipmentRegisterPopup
window.downloadFile = function (filename, bytesBase64) {
    const link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/pdf;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}
