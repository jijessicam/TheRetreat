﻿using System.Collections;
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {

        transform.Rotate(0, horizontal, 0);
        transform.Translate(0, 0, vertical);
    }