(async () => {
    // This method will trigger user permissions
    try {
        /**
        * devices would be an array of objects of type:
        * { id: "id", label: "label" }
        */
        var devices = await Html5Qrcode.getCameras();
        if (devices && devices.length) {
            var cameraId = devices[0].id;
            // Create instance of the object. The only argument is the "id" of HTML element created above.
            const html5QrCode = new Html5Qrcode("reader");
            try {
                html5QrCode.start(
                    cameraId,     // retreived in the previous step.
                    {
                        fps: 2,    // sets the framerate to 10 frame per second
                        //qrbox: 250  // sets only 250 X 250 region of viewfinder to
                        // scannable, rest shaded.
                    },
                    async qrCodeMessage => {
                        try {
                            await html5QrCode.stop();
                            console.log("QR Code scanning stopped.");
                        } catch (err) {
                            // Stop failed, handle it.
                            console.log("Unable to stop scanning.");
                        };
                        // do something when code is read. For example:
                        console.log(`QR Code detected: ${qrCodeMessage}`);
                        document.getElementById("qrdata").value = qrCodeMessage;
                        document.getElementById("qr_form").submit();

                    },
                    errorMessage => {
                        // parse error, ideally ignore it. For example:
                        console.log(`QR Code no longer in front of camera.`);
                    });
            } catch (err) {
                // Start failed, handle it. For example,
                console.log(`Unable to start scanning, error: ${err}`);
            }
        }
    }
    catch (err) {
        console.log(err);
    }
})();