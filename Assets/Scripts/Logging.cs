using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Logging : MonoBehaviour
{
    //LOGGING VARIABLES
    public string path;
    public float time = 0;
    // !!! FOR MULTIPLE PARTICIPANTS INCREMENT ID TO DIFFERENTIATE WITHIN UNITY UI !!!
    public int participantID = 1;
    public int interactionID = 0;
    //LEFT HAND BONES
    public GameObject b_l_wrist;
    public GameObject b_l_forearm;
    public GameObject b_l_thumb0;
    public GameObject b_l_thumb1;
    public GameObject b_l_thumb2;
    public GameObject b_l_thumb3;
    public GameObject b_l_index1;
    public GameObject b_l_index2;
    public GameObject b_l_index3;
    public GameObject b_l_middle1;
    public GameObject b_l_middle2;
    public GameObject b_l_middle3;
    public GameObject b_l_ring1;
    public GameObject b_l_ring2;
    public GameObject b_l_ring3;
    public GameObject b_l_pinky0;
    public GameObject b_l_pinky1;
    public GameObject b_l_pinky2;
    public GameObject b_l_pinky3;
    public GameObject l_thumb_finger_tip_marker;
    public GameObject l_index_finger_tip_marker;
    public GameObject l_middle_finger_tip_marker;
    public GameObject l_ring_finger_tip_marker;
    public GameObject l_pinky_finger_tip_marker;
    //RIGHT HAND BONES
    public GameObject b_r_wrist;
    public GameObject b_r_forearm;
    public GameObject b_r_thumb0;
    public GameObject b_r_thumb1;
    public GameObject b_r_thumb2;
    public GameObject b_r_thumb3;
    public GameObject b_r_index1;
    public GameObject b_r_index2;
    public GameObject b_r_index3;
    public GameObject b_r_middle1;
    public GameObject b_r_middle2;
    public GameObject b_r_middle3;
    public GameObject b_r_ring1;
    public GameObject b_r_ring2;
    public GameObject b_r_ring3;
    public GameObject b_r_pinky0;
    public GameObject b_r_pinky1;
    public GameObject b_r_pinky2;
    public GameObject b_r_pinky3;
    public GameObject r_thumb_finger_tip_marker;
    public GameObject r_index_finger_tip_marker;
    public GameObject r_middle_finger_tip_marker;
    public GameObject r_ring_finger_tip_marker;
    public GameObject r_pinky_finger_tip_marker;
    
    // INITIALISES COLUMNS
    void Start()
    {
        path = Application.dataPath + "/Log.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Participant,Interaction,Hand,Bone,X,Y,Z,Time\n");
        }
        b_l_wrist = GameObject.Find("b_l_wrist");
        b_l_forearm = GameObject.Find("b_l_forearm_stub");
        b_l_thumb0 = GameObject.Find("b_l_thumb0");
        b_l_thumb1 = GameObject.Find("b_l_thumb1");
        b_l_thumb2 = GameObject.Find("b_l_thumb2");
        b_l_thumb3 = GameObject.Find("b_l_thumb3");
        b_l_index1 = GameObject.Find("b_l_index1");
        b_l_index2 = GameObject.Find("b_l_index2");
        b_l_index3 = GameObject.Find("b_l_index3");
        b_l_middle1 = GameObject.Find("b_l_middle1");
        b_l_middle2 = GameObject.Find("b_l_middle2");
        b_l_middle3 = GameObject.Find("b_l_middle3");
        b_l_ring1 = GameObject.Find("b_l_ring1");
        b_l_ring2 = GameObject.Find("b_l_ring2");
        b_l_ring3 = GameObject.Find("b_l_ring3");
        b_l_pinky0 = GameObject.Find("b_l_pinky0");
        b_l_pinky1 = GameObject.Find("b_l_pinky1");
        b_l_pinky2 = GameObject.Find("b_l_pinky2");
        b_l_pinky3 = GameObject.Find("b_l_pinky3");
        l_thumb_finger_tip_marker = GameObject.Find("l_thumb_finger_tip_marker");
        l_index_finger_tip_marker = GameObject.Find("l_index_finger_tip_marker");
        l_middle_finger_tip_marker = GameObject.Find("l_middle_finger_tip_marker");
        l_ring_finger_tip_marker = GameObject.Find("l_ring_finger_tip_marker");
        l_pinky_finger_tip_marker = GameObject.Find("l_pinky_finger_tip_marker");
        //RIGHT HAND BONES
        b_r_wrist = GameObject.Find("b_r_wrist");
        b_r_forearm = GameObject.Find("b_r_forearm_stub");
        b_r_thumb0 = GameObject.Find("b_r_thumb0");
        b_r_thumb1 = GameObject.Find("b_r_thumb1");
        b_r_thumb2 = GameObject.Find("b_r_thumb2");
        b_r_thumb3 = GameObject.Find("b_r_thumb3");
        b_r_index1 = GameObject.Find("b_r_index1");
        b_r_index2 = GameObject.Find("b_r_index2");
        b_r_index3 = GameObject.Find("b_r_index3");
        b_r_middle1 = GameObject.Find("b_r_middle1");
        b_r_middle2 = GameObject.Find("b_r_middle2");
        b_r_middle3 = GameObject.Find("b_r_middle3");
        b_r_ring1 = GameObject.Find("b_r_ring1");
        b_r_ring2 = GameObject.Find("b_r_ring2");
        b_r_ring3 = GameObject.Find("b_r_ring3");
        b_r_pinky0 = GameObject.Find("b_r_pinky0");
        b_r_pinky1 = GameObject.Find("b_r_pinky1");
        b_r_pinky2 = GameObject.Find("b_r_pinky2");
        b_r_pinky3 = GameObject.Find("b_r_pinky3");
        r_thumb_finger_tip_marker = GameObject.Find("r_thumb_finger_tip_marker");
        r_index_finger_tip_marker = GameObject.Find("r_index_finger_tip_marker");
        r_middle_finger_tip_marker = GameObject.Find("r_middle_finger_tip_marker");
        r_ring_finger_tip_marker = GameObject.Find("r_ring_finger_tip_marker");
        r_pinky_finger_tip_marker = GameObject.Find("r_pinky_finger_tip_marker");
    }

    // WHILE HOLDING F ALL HAND DATA POINTS X,Y,Z WILL BE STORED IN LOG FILE
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            //INCREMENTS INTERACTION ID TO DIFFERENTIATE INTERACTIONS
            interactionID +=1;
            //RESETS TIME FOR EACH INTERACTION
            time = 0;
        }
        if (Input.GetKey(KeyCode.KeypadEnter))
        {
            //ADDS THE TIME TAKEN TO DISPLAY THE FRAME TO GLOBAL TIME VARIABLE
            time += Time.deltaTime;
            string content = participantID + "," + interactionID + ",L," + b_l_wrist.name + "," + b_l_wrist.transform.position.x + "," + b_l_wrist.transform.position.y + "," + b_l_wrist.transform.position.z + ","+(time*1000).ToString()+"\n"
                + participantID + "," + interactionID + ",L," + b_l_forearm.name + "," + b_l_forearm.transform.position.x + "," + b_l_forearm.transform.position.y + "," + b_l_forearm.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_thumb0.name + "," + b_l_thumb0.transform.position.x + "," + b_l_thumb0.transform.position.y + "," + b_l_thumb0.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_thumb1.name + "," + b_l_thumb1.transform.position.x + "," + b_l_thumb1.transform.position.y + "," + b_l_thumb1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_thumb2.name + "," + b_l_thumb2.transform.position.x + "," + b_l_thumb2.transform.position.y + "," + b_l_thumb2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_thumb3.name + "," + b_l_thumb3.transform.position.x + "," + b_l_thumb3.transform.position.y + "," + b_l_thumb3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_index1.name + "," + b_l_index1.transform.position.x + "," + b_l_index1.transform.position.y + "," + b_l_index1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_index2.name + "," + b_l_index2.transform.position.x + "," + b_l_index2.transform.position.y + "," + b_l_index2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_index3.name + "," + b_l_index3.transform.position.x + "," + b_l_index3.transform.position.y + "," + b_l_index3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_middle1.name + "," + b_l_middle1.transform.position.x + "," + b_l_middle1.transform.position.y + "," + b_l_middle1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_middle2.name + "," + b_l_middle2.transform.position.x + "," + b_l_middle2.transform.position.y + "," + b_l_middle2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_middle3.name + "," + b_l_middle3.transform.position.x + "," + b_l_middle3.transform.position.y + "," + b_l_middle3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_ring1.name + "," + b_l_ring1.transform.position.x + "," + b_l_ring1.transform.position.y + "," + b_l_ring1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_ring2.name + "," + b_l_ring2.transform.position.x + "," + b_l_ring2.transform.position.y + "," + b_l_ring2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_ring3.name + "," + b_l_ring3.transform.position.x + "," + b_l_ring3.transform.position.y + "," + b_l_ring3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_pinky0.name + "," + b_l_pinky0.transform.position.x + "," + b_l_pinky0.transform.position.y + "," + b_l_pinky0.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_pinky1.name + "," + b_l_pinky1.transform.position.x + "," + b_l_pinky1.transform.position.y + "," + b_l_pinky1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_pinky2.name + "," + b_l_pinky2.transform.position.x + "," + b_l_pinky2.transform.position.y + "," + b_l_pinky2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + b_l_pinky3.name + "," + b_l_pinky3.transform.position.x + "," + b_l_pinky3.transform.position.y + "," + b_l_pinky3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + l_thumb_finger_tip_marker.name + "," + l_thumb_finger_tip_marker.transform.position.x + "," + l_thumb_finger_tip_marker.transform.position.y + "," + l_thumb_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + l_index_finger_tip_marker.name + "," + l_index_finger_tip_marker.transform.position.x + "," + l_index_finger_tip_marker.transform.position.y + "," + l_index_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + l_middle_finger_tip_marker.name + "," + l_middle_finger_tip_marker.transform.position.x + "," + l_middle_finger_tip_marker.transform.position.y + "," + l_middle_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + l_ring_finger_tip_marker.name + "," + l_ring_finger_tip_marker.transform.position.x + "," + l_ring_finger_tip_marker.transform.position.y + "," + l_ring_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",L," + l_pinky_finger_tip_marker.name + "," + l_pinky_finger_tip_marker.transform.position.x + "," + l_pinky_finger_tip_marker.transform.position.y + "," + l_pinky_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_wrist.name + "," + b_r_wrist.transform.position.x + "," + b_r_wrist.transform.position.y + "," + b_r_wrist.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_forearm.name + "," + b_r_forearm.transform.position.x + "," + b_r_forearm.transform.position.y + "," + b_r_forearm.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_thumb0.name + "," + b_r_thumb0.transform.position.x + "," + b_r_thumb0.transform.position.y + "," + b_r_thumb0.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_thumb1.name + "," + b_r_thumb1.transform.position.x + "," + b_r_thumb1.transform.position.y + "," + b_r_thumb1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_thumb2.name + "," + b_r_thumb2.transform.position.x + "," + b_r_thumb2.transform.position.y + "," + b_r_thumb2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_thumb3.name + "," + b_r_thumb3.transform.position.x + "," + b_r_thumb3.transform.position.y + "," + b_r_thumb3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_index1.name + "," + b_r_index1.transform.position.x + "," + b_r_index1.transform.position.y + "," + b_r_index1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_index2.name + "," + b_r_index2.transform.position.x + "," + b_r_index2.transform.position.y + "," + b_r_index2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_index3.name + "," + b_r_index3.transform.position.x + "," + b_r_index3.transform.position.y + "," + b_r_index3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_middle1.name + "," + b_r_middle1.transform.position.x + "," + b_r_middle1.transform.position.y + "," + b_r_middle1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_middle2.name + "," + b_r_middle2.transform.position.x + "," + b_r_middle2.transform.position.y + "," + b_r_middle2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_middle3.name + "," + b_r_middle3.transform.position.x + "," + b_r_middle3.transform.position.y + "," + b_r_middle3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_ring1.name + "," + b_r_ring1.transform.position.x + "," + b_r_ring1.transform.position.y + "," + b_r_ring1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_ring2.name + "," + b_r_ring2.transform.position.x + "," + b_r_ring2.transform.position.y + "," + b_r_ring2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_ring3.name + "," + b_r_ring3.transform.position.x + "," + b_r_ring3.transform.position.y + "," + b_r_ring3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_pinky0.name + "," + b_r_pinky0.transform.position.x + "," + b_r_pinky0.transform.position.y + "," + b_r_pinky0.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_pinky1.name + "," + b_r_pinky1.transform.position.x + "," + b_r_pinky1.transform.position.y + "," + b_r_pinky1.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_pinky2.name + "," + b_r_pinky2.transform.position.x + "," + b_r_pinky2.transform.position.y + "," + b_r_pinky2.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + b_r_pinky3.name + "," + b_r_pinky3.transform.position.x + "," + b_r_pinky3.transform.position.y + "," + b_r_pinky3.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + r_thumb_finger_tip_marker.name + "," + r_thumb_finger_tip_marker.transform.position.x + "," + r_thumb_finger_tip_marker.transform.position.y + "," + r_thumb_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + r_index_finger_tip_marker.name + "," + r_index_finger_tip_marker.transform.position.x + "," + r_index_finger_tip_marker.transform.position.y + "," + r_index_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + r_middle_finger_tip_marker.name + "," + r_middle_finger_tip_marker.transform.position.x + "," + r_middle_finger_tip_marker.transform.position.y + "," + r_middle_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + r_ring_finger_tip_marker.name + "," + r_ring_finger_tip_marker.transform.position.x + "," + r_ring_finger_tip_marker.transform.position.y + "," + r_ring_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n"
                + participantID + "," + interactionID + ",R," + r_pinky_finger_tip_marker.name + "," + r_pinky_finger_tip_marker.transform.position.x + "," + r_pinky_finger_tip_marker.transform.position.y + "," + r_pinky_finger_tip_marker.transform.position.z + "," + (time * 1000).ToString() + "\n";
            File.AppendAllText(path, content);

        }
    }
}
