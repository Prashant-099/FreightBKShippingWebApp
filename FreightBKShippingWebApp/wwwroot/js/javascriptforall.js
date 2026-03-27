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

function closeMobileMenuIfNeeded() {
    if (window.innerWidth < 768) {
        // This depends on how you're toggling your nav
        document.getElementById('mobile-menu-wrapper')?.classList.remove('show');
        document.getElementById('sidebar')?.classList.remove('auto-expanded');
    }
}
//js for focus and tab index!!
window.downloadFileFromBytes = function (fileName, base64Data) {
    const link = document.createElement('a');
    link.href = "data:application/pdf;base64," + base64Data;
    link.download = fileName;
    link.click();
}

//-----=
window.generateLandscapePdfBase64 = async function (elementId) {
    const element = document.getElementById(elementId);
    const opt = {
        margin: 5,
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2 },
        jsPDF: {
            unit: 'mm',
            format: 'a4',
            orientation: 'landscape'
        }
    };
    const worker = html2pdf().set(opt).from(element).toPdf();
    const pdf = await worker.get('pdf');
    return pdf.output('datauristring').split(',')[1];
};


window.downloadFile = function (filename, bytesBase64) {
    const link = document.createElement('a');
    link.download = filename;
    link.href = "data:application/pdf;base64," + bytesBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

//sds
// ✔️ Download a file from a .NET stream (PDF)
window.downloadPdfFromStream = async function (fileName, dotNetStreamRef) {
    if (!dotNetStreamRef) {
        console.error("Stream reference is null");
        return;
    }

    try {
        const arrayBuffer = await dotNetStreamRef.arrayBuffer();
        const blob = new Blob([arrayBuffer], { type: "application/pdf" });

        const url = URL.createObjectURL(blob);
        const a = document.createElement("a");
        a.href = url;
        a.download = fileName ?? "download.pdf";

        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);

        URL.revokeObjectURL(url);
    }
    catch (err) {
        console.error("Download failed:", err);
    }
}

//preview pdf
window.previewPdfFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer], { type: "application/pdf" });
    const url = URL.createObjectURL(blob);
    window.open(url, "_blank");
};

//pdf download
window.downloadFileFromBytes = function (fileName, base64Data) {
    const link = document.createElement('a');
    link.href = "data:application/pdf;base64," + base64Data;
    link.download = fileName;
    link.click();
}

//pdf preview
window.openPdfPreview = async function (dotNetStreamRef) {
    if (!dotNetStreamRef) {
        console.error("dotNetStreamRef is null");
        return;
    }

    try {
        const arrayBuffer = await dotNetStreamRef.arrayBuffer();
        const blob = new Blob([arrayBuffer], { type: "application/pdf" });
        const url = URL.createObjectURL(blob);

        window.open(url, "_blank");
    } catch (err) {
        console.error("PDF preview failed:", err);
    }
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

window.scrollToBottom = function (elementId) {
    setTimeout(function () {
        const el = document.getElementById(elementId);
        if (!el) return;
        el.scrollTop = el.scrollHeight;

        // Jab bhi image/video load ho, phir se scroll karo
        const mediaItems = el.querySelectorAll('img, video');
        mediaItems.forEach(function (media) {
            media.addEventListener('load', function () { el.scrollTop = el.scrollHeight; });
            media.addEventListener('loadedmetadata', function () { el.scrollTop = el.scrollHeight; });
        });
    }, 300);
};
